import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  errorMessage = "";
  libeyUsers: LibeyUser[] = [];

  constructor(
    private router: Router,
    private libeyUserService: LibeyUserService,
  ) {}

  ngOnInit(): void {
    this.getAllUsers()
  }

 getAllUsers(){
  this.libeyUserService.GetAll().subscribe({
    next: (users) => {
      this.libeyUsers = users;
    },
    error: (err) => (this.errorMessage = err),
  });
 }

  onDeleteUser(document: string) {

    this.libeyUserService.deleteUser(document)
    .subscribe( user => {
      this.getAllUsers()
    });
  }



}
