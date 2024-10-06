import moment from 'moment/moment'
import '../styles/Note.css'

export function Note({title, description, createAt}) {
    return(
        <div>
            <h6>{title}</h6>
            <hr/>
            <label>{description}</label>
            <hr/>
            <label>{moment(createAt).format("DD.MM.YYYY HH:mm")}</label>
        </div>
    )
}