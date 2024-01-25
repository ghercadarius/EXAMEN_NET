import { Participant } from "./Participant";

export interface Eveniment{
    nume: string;
    locatie: string;
    data: string;
    Id: String;
    Participanti: Participant[];
}