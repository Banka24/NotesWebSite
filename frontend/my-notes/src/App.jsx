import './styles/App.css';
import { CreateNoteForm } from './components/CreateNoteForm';
import { Note } from './components/Note';
import { Filter } from './components/Filter';
import { useEffect, useState } from 'react';
import { createNote, fetchNotes } from './services/note';

function App() {
  const [notes, setNotes] = useState([]);
  const [filter, setFilter] = useState({
    search: '',
    sortItem: "date",
    sortOrder: "desc",
  });

  useEffect(() => {
    const fetchData = async () => {
      let notes = await fetchNotes(filter);
      setNotes(notes);
    };
    fetchData();
  }, [filter]);

  const onCreate = async (note) => {
    await createNote(note);
    let notes = await fetchNotes(filter);
    setNotes(notes);
  }

  return (
    <section className='p-8 flex flex-row justify-start items-start gap-12'>
      <div className='flex flex-col w-1/3 gap-10'>
        <CreateNoteForm onCreate={onCreate}/>
        <Filter filter={filter} setFilter={setFilter} />
      </div>
      <ul className="flex flex-col gap-5 w-1/2">
        {notes.map((note) => (
          <li key={note.id}>
            <Note
              title={note.title}
              description={note.description}
              createAt={note.createAt}
            />
          </li>
        ))}
      </ul>
    </section>
  );
}

export default App;