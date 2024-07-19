import { Message } from "./Message";
import { NameId } from "./NameId";

export interface DirectMessage extends Message{
    receivers: NameId[]
}

export interface DirectMessageDto extends Message {
    receiverIds: number[];
}