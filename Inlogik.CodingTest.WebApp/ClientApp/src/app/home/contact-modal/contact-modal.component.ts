import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Contact } from 'src/app/shared/models/contact.model';

@Component({
  selector: 'app-contact-modal',
  templateUrl: 'contact-modal.component.html',
  styleUrls: [
    'contact-modal.component.scss'
  ]
})

export class ContactModalComponent implements OnInit {

  form: FormGroup;
  
  constructor(
    public dialogRef: MatDialogRef<ContactModalComponent>,
    @Inject(MAT_DIALOG_DATA) public contact: Contact,
    private fb: FormBuilder
  ) {}

  ngOnInit() { 
    this.form = this.fb.group({
      name: [this.contact ? this.contact.name : null, Validators.required],
      phone: [this.contact ? this.contact.phone : null],
      email: [this.contact ? this.contact.email : null],
    });
  }

  onNoClick(): void {
    this.dialogRef.close(null);
  }
}