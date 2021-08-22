import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from 'src/app/shared/models/contact.model';

@Injectable({providedIn: 'root'})
export class ContactApiService {
  constructor(
    private httpClient: HttpClient
  ) { }
  
  getList(): Observable<Contact[]> {
    return this.httpClient.get<Contact[]>('api/contacts');
  }

  add(contact: Contact): Observable<Contact> {
    return this.httpClient.post<Contact>('api/contacts', contact);
  }

  update(id: number, contact: Contact): Observable<Contact> {
    return this.httpClient.put<Contact>(`api/contacts/${id}`, contact);
  }
}