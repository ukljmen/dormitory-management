import { NameId } from "./NameId";

export interface Student extends NameId {
    firstName: string,
    lastName: string,
    indexNumber: string,
    userId: number
}