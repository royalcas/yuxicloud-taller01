import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateValueComponent } from './create-value.component';

describe('CreateValueComponent', () => {
  let component: CreateValueComponent;
  let fixture: ComponentFixture<CreateValueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateValueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateValueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
