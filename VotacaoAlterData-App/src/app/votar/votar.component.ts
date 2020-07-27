import { Component, OnInit } from '@angular/core';
import { Voto } from '../_models/Voto';
import { ItemRecurso } from '../_models/ItemRecurso';


@Component({
  selector: 'app-votar',
  templateUrl: './votar.component.html',
  styleUrls: ['./votar.component.css']
})
export class VotarComponent implements OnInit {

  constructor() { }
  titulo = 'Votar';
  voto: Voto;
  votos: Voto[];
  itensRecurso: ItemRecurso[];

  ngOnInit() {
  }

}
