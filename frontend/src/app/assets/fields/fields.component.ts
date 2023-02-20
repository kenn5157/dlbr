import { Component, OnInit } from '@angular/core';

import { Field } from 'src/app/field';
import { FieldService } from 'src/app/services/field.service';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.scss']
})

export class FieldsComponent {

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
