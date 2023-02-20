import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyFieldsComponent } from './my-fields.component';

describe('MyFieldsComponent', () => {
  let component: MyFieldsComponent;
  let fixture: ComponentFixture<MyFieldsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyFieldsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyFieldsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
