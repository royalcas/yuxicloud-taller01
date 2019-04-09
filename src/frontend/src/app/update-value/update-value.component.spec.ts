import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateValueComponent } from './update-value.component';

describe('UpdateValueComponent', () => {
  let component: UpdateValueComponent;
  let fixture: ComponentFixture<UpdateValueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateValueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateValueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
