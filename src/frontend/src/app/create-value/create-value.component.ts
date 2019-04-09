import { ValueService } from './../core/value.service';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Value } from '../core/models/value.model';

@Component({
  selector: 'app-create-value',
  templateUrl: './create-value.component.html',
  styleUrls: ['./create-value.component.scss']
})
export class CreateValueComponent implements OnInit {
  value: string;
  oldValue: Value;

  constructor(
    private valueService: ValueService,
    public dialogRef: MatDialogRef<CreateValueComponent>
  ) {}

  ngOnInit() {}

  save() {
    if (!this.oldValue) {
      this.valueService.post(this.value).subscribe(() => {
        this.dialogRef.close();
      });
      return;
    }

    this.valueService
      .put({ id: this.oldValue.id, value: this.value })
      .subscribe(() => {
        this.dialogRef.close();
      });
  }
}
