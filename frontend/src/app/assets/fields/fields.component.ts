import { Component, OnInit } from '@angular/core';

import { Field } from 'src/app/field';
import { FieldService } from 'src/app/services/field.service';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.scss']
})

export class FieldsComponent {

  add(_fieldName: string,
    _fieldSize: number,
    _animalCount: number,
    _cropType: string,
    _status: string,
    _changeDate: Date) {
    var field: Field = {
      id: 0,
      fieldName: _fieldName,
      fieldSize: _fieldSize,
      animalCount: _animalCount,
      cropTrype: _cropType,
      status: _status,
      changeDate: _changeDate
    }

    this.fieldService.addField(field)
      .subscribe(field => {
        this.fields.push(field);
      });
  }


  constructor(private fieldService: FieldService) { }

  fields: Field[] = [];

  ngOnInit(): void {
    this.getFields();
  }

  getFields(): void {
    this.fieldService.getFields()
      .subscribe(_fields => this.fields = _fields);
  }
}
