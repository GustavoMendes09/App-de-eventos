import { Evento } from "./Evento";
import { Palestrante } from "./Palestrante";

export interface RedeSocial {
uRL: string;
eventoId?: number;
evento: Evento;
palestranteId?: number;
palestrante: Palestrante;
}
