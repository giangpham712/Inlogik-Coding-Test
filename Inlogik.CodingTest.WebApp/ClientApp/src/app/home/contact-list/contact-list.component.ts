import { EventEmitter, Output, SimpleChanges } from '@angular/core';
import { ChangeDetectionStrategy, Component, Input, OnChanges, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

import { Contact } from 'src/app/shared/models/contact.model';

@Component({
  selector: 'app-contact-list',
  templateUrl: 'contact-list.component.html',
  styleUrls: [
    'contact-list.component.scss'
  ],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class ContactListComponent implements OnInit, OnChanges {

  @Input()
  contacts: Contact[];

  @Output()
  edit = new EventEmitter<Contact>();

  displayedColumns = ['name', 'action'];

  dataSource = new MatTableDataSource<Contact>([]);

  constructor() { }

  ngOnInit() { 
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['contacts']) {
      this.dataSource.data = this.contacts;
    }
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}