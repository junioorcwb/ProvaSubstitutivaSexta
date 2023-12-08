import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IMC } from 'src/models/IMC.models';

@Component({
  selector: 'app-root',
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  
  constructor(
    private client: HttpClient,
    private router : Router,
  ){

  }
  
  ngOnInit(){
    this.client
      .get<IMC[]>("https://localhost:7181/IMC/listar")
      .subscribe({
        next: (imcs) => {
          this.IMCs = imcs
          console.log(this.IMCs)
        }
      })
  }

  title = 'SubsFRONT';
  IMCs : IMC[] = []

  
}
