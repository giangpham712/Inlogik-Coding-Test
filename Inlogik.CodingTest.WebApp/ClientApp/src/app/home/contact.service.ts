import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ContactApiService } from '../core/services/api/contact-api.service';
import { Contact } from '../shared/models/contact.model';

@Injectable()
export class ContactService {

  private contactsSource = new BehaviorSubject<Contact[]>([]);
  contacts$ = this.contactsSource.asObservable();

  constructor(
    private contactApi: ContactApiService
  ) { }
  
  loadContacts() {
    this.contactApi.getList().subscribe(
      contacts => this.contactsSource.next(contacts)
    );
  }

  addContact(contact: Contact) {
    this.contactApi.add(contact).subscribe(
      createdContact => {
        const contacts = [ ...this.contactsSource.getValue(), createdContact ];
        this.contactsSource.next(contacts);
      }
    );
  }

  updateContact(id: number, contact: Contact) {
    this.contactApi.update(id, contact).subscribe(
      updatedContact => {
        const contacts = this.contactsSource.getValue().map(
          c => {
            if (c.id === updatedContact.id) {
              return updatedContact;
            }

            return c;
          }
        );

        this.contactsSource.next(contacts);
      }
    );
  }
}