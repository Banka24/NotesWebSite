import { useState } from 'react';
import '../styles/CreateNoteForm.css';

export function CreateNoteForm({onCreate}){
    const [note, setNote] = useState(null);
    const onSubmit = (e) => {
      e.preventDefault();
      setNote(null);
      onCreate(note);
    }

    return(
    <form onSubmit={onSubmit}>
      <h3>Создание заметки</h3>
      <input type="text" placeholder="Название заметки" value={note?.title ?? ""} onChange={(e) => setNote({...note, title: e.target.value})}/>
      <textarea placeholder="Описание заметки" value={note?.description ?? ""} onChange={(e) => setNote({...note, description: e.target.value})}/>
      <button type='submit'>Создать</button>
    </form>
    )
}