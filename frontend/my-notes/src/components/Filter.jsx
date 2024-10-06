import '../styles/Filter.css';

export function Filter({filter, setFilter}) {
    return(
        <div>
          <input placeholder='Поиск' onChange={(e) => setFilter({...filter, search: e.target.value})}/>
          <select onChange={(e) => setFilter({...filter, sortOrder: e.target.value})}>
            <option value={"desc"}>Сначала новые</option>
            <option value={"asc"}>Сначала старые</option>
          </select>
        </div>
    )
}