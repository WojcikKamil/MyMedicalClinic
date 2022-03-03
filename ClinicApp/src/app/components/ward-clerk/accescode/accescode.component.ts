import { Component, OnInit } from '@angular/core';
import { AccesCode } from 'src/app/models/accesCode';
import { CodeService } from 'src/app/services/code.service';

@Component({
  selector: 'app-accescode',
  templateUrl: './accescode.component.html',
  styleUrls: ['./accescode.component.scss']
})
export class AccescodeComponent implements OnInit {

  code!: AccesCode;

  constructor(private codeService: CodeService) { }

  ngOnInit(): void {
  }

  generateCode(){
    this.codeService.generateAccesCode().subscribe(response => {
      this.code = response;
      console.log(this.code);
    });
  }
}
