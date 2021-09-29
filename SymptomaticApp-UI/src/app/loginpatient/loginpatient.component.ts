import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loginpatient',
  templateUrl: './loginpatient.component.html',
  styleUrls: ['./loginpatient.component.css']
})
export class LoginPatientComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  login(username: string, password: string) {//todo check if these are valid inputs

  }
}
