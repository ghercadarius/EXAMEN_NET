import { Eveniment } from "./Eveniment";

export interface Participant{
    nume: string;
    prenume: string;
    Id: string;
    Evenimente: Eveniment[];
}
