import { NameId } from "./NameId";

export interface Message{
    id: number,
    title: string,
    content: string,
    addedTS: Date,
    author: NameId
}