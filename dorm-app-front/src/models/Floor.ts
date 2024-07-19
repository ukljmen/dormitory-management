import { NameId } from "./NameId"
import { Student } from "./Student"
import { Ticket } from "./Ticket"

export interface Floor {
    id: number,
    floorNumber: number,
    rooms: RoomSimple[]
}

export interface RoomSimple {
    id: number,
    roomNumber: number,
    students: Student[]
}

export interface Room extends RoomSimple {
    items : NameId[],
    problems : Ticket[]
}