import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'frontend';
  fieldName: string = '';
  fieldSize: number = 0;
  animalGroupId: number = 0;
  animalCount: number = 0;
  cropType: string = '';
  status: string = '';
  lastChange: Date = new Date();
  fields: any;


  async ngOnInit() {
    const fields = await this.http.getProducts();
    this.fields = fields.data;
  }

  constructor(private http: HttpService) {  }


  async createField() {
    let dto = {
      fieldName: this.fieldName,
      fieldSize: this.fieldSize,
      animalGroupId: this.animalGroupId,
      animalCount: this.animalCount,
      cropType: this.cropType,
      status: this.status,
      lastChange: this.lastChange
    }
    const result = await this.http.createProduct(dto);
    this.fields.push(result);
  }
  writeFieldName() {
    console.log(this.fieldName)
  }
}
