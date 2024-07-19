import { useCallback, useState } from "react";
import './DirectMessageComponent.css';
import { Message } from "../../models/Message";
import { NameId } from "../../models/NameId";
import { SendDirectMessage, UpdateDirectMessage } from "../../services/DirectMessagesService";

const DirectMessageComponent = ({input, receivers, parentReload} 
  : {input? : Message | null, receivers: NameId[] | null, parentReload: () => void}) => {
  const [messageId, setMessageId] = useState<number>(input?.id ?? 0);
  const [title, setTitle] = useState(input?.title ?? "");
  const [body, setBody] = useState(input?.content ?? "");

  const handleSubmit = useCallback(() => {
    const message = {
      messageId: messageId,
      title: title,
      content: body,
      receiverIds: receivers!.map(r => r.id)
    };

    if(messageId === 0){
      SendDirectMessage(message)
        .then((res) =>{
          console.log(res);
        })
        .catch((err) => {
          console.log(err);
        });
    } else {
      UpdateDirectMessage(message)
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
    <div className="DirectMessageComponent">
      <h2>Wyślij wiadomość do: {receivers?.map(r => r.name + ', ')}</h2>
      {/* <form onSubmit={handleSubmit}> */}
      <form>
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
        <button onClick={handleSubmit}>Wyślij</button>
      </form>
    </div>
  );
};

export default DirectMessageComponent;
