import { useCallback, useState } from "react";
import { Props } from "../../models/Props";
import './MessageComponent.css';
import { AddNews, UpdateNews } from "../../services/NewsService";
import { Message } from "../../models/Message";

const MessageComponent = ({input, parentReload} : {input? : Message | null, parentReload: () => void}) => {
  const [id, setId] = useState<number>(input?.id ?? 0);
  const [title, setTitle] = useState(input?.title ?? "");
  const [body, setBody] = useState(input?.content ?? "");

  const handleSubmit = useCallback(() => {
    const message = { id: id, title: title, content: body };
    if(id === 0){
      AddNews(message)
        .then((res) =>{
          console.log(res);
        })
        .catch((err) => {
          console.log(err);
        });
    } else {
      UpdateNews(message)
        .then((res) =>{
          console.log(res);
        })
        .catch((err) => {
          console.log(err);
        });
    }

    parentReload();
  }, [title, body]);

  return (
    <div className="MessageComponent">
      <h2>Opublikuj wiadomość</h2>
      <form onSubmit={handleSubmit}>
        <div className="inputContainer">
          <input
            placeholder="Tytuł"
            type="text"
            required
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          ></input>
        </div>
        <div>
          <textarea
            placeholder="Treść"
            required
            value={body}
            onChange={(e) => setBody(e.target.value)}
          ></textarea>
        </div>
        <button>Wyślij</button>
      </form>
    </div>
  );
};

export default MessageComponent;
