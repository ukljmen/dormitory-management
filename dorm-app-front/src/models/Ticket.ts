import { NameId } from "./NameId";

export interface Ticket {
    id: number,
    description: string,
    status: TicketStatus,
    item?: NameId,
    conservator?: NameId
}

export enum TicketStatus {
    Resolved = 0,
    Sent,
    Assigned,
    InProgress,
    Fixed
}