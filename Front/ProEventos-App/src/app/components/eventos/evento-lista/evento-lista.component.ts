import { Router } from '@angular/router';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/Evento.service';
import { environment } from '@environments/environment';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
  modalRef!: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public mostrarImagem: boolean = true;
  private filtroListado: string = '';
  public eventoId = 0;

  public get filtroLista(){
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;

    this.eventosFiltrados = this.filtroLista ?
     this.filtrarEventos(this.filtroLista) :
     this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: any) =>
       evento.tema.toLocaleLowerCase()
      .indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase()
      .indexOf(filtrarPor) !== -1
    )
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
    ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.carregarEventos();

  }

  public alterImg(): void{
    this.mostrarImagem = !this.mostrarImagem
  }

  public mostraImagem(imagemURL: string): string{
    return (imagemURL != '')
    ? `${environment.apiURL}resources/images/${imagemURL}`
    : 'assets/registerImage.png'
  }

  public carregarEventos(): void{
  this.eventoService.getEventos().subscribe({
    next: (eventos: Evento[])=> {
      this.eventos = eventos;
      this.eventosFiltrados = this.eventos;
    },
    error: (error: any) => {
      this.spinner.hide();
      this.toastr.error('Erro ao carregar os eventos.','Error!');
    },
    complete: () => this.spinner.hide()
  });
  }

  openModal(event: any, template: TemplateRef<any>, eventoId: number): void{
    event.stopPropagation();
    this.eventoId = eventoId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm():void {
    this.modalRef.hide();
    this.spinner.show();

    this.eventoService.deleteEvento(this.eventoId).subscribe(
      (result: any) => {
          this.toastr.success('O evento foi deletado com sucesso', 'Deletado!');
          this.spinner.hide();
          this.carregarEventos();
      },
      (error: any) => {
        this.toastr.error(`Erro ao tentar deletar o evento ${this.eventoId}`, 'Erro')
        console.error(error);
        this.spinner.hide();
      },
      () => this.spinner.hide(),
    );
  }

  decline(): void {
    this.modalRef.hide();
  }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`])
  }
}
