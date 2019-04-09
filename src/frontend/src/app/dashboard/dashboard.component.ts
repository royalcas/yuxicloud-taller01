import { Value } from './../core/models/value.model';
import { CreateValueComponent } from './../create-value/create-value.component';
import { ValueService } from './../core/value.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  values$: Observable<Value[]>;
  destroy$ = new Subject();

  constructor(private valueService: ValueService, private dialog: MatDialog) {}

  ngOnInit() {
    this.fetchValues();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
  }

  fetchValues(): void {
    this.values$ = this.valueService.getAll().pipe(takeUntil(this.destroy$));
  }

  newValue() {
    this.dialog
      .open(CreateValueComponent)
      .afterClosed()
      .subscribe(() => {
        this.fetchValues();
      });
  }

  edit(currentValue: Value) {
    const dialogRef = this.dialog.open(CreateValueComponent);

    dialogRef.componentInstance.oldValue = currentValue;
    dialogRef.afterClosed().subscribe(() => {
      this.fetchValues();
    });
  }

  delete(id: number) {
    this.valueService.delete(id).subscribe(() => {
      this.fetchValues();
    });
  }
}
