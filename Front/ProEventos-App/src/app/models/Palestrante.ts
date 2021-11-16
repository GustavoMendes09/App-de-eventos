import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
  nome: string;
  minuCurriculo: string;
  imagemURL: string;
  telefone: string;
  email: string;
  redesSociais: RedeSocial;
  palestranteEventos: Evento;
}
