import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Contact } from '../shared/models/contact.model';
import { ContactModalComponent } from './contact-modal/contact-modal.component';
import { ContactService } from './contact.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [
    ContactService
  ]
})
export class HomeComponent implements OnInit {
  
  constructor(
    public dialog: MatDialog,
    public contactService: ContactService
  ) {

  }

  ngOnInit(): void {
    this.contactService.loadContacts();
  }

  addContact() {
    const dialogRef = this.dialog.open(ContactModalComponent, {
      width: '500px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) {
        return;
      }

      this.contactService.addContact(result);
    });
  }

  editContact(contact: Contact) {
    const dialogRef = this.dialog.open(ContactModalComponent, {
      width: '500px',
      data: contact
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) {
        return;
      }
      
      this.contactService.updateContact(contact.id, result);
    });
  }
}
