import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select";
import { RouterModule } from '@angular/router';

import { UsercardsComponent } from './usercards/usercards.component';
import { UserlistComponent } from './userlist/userlist.component';
import { UsermaintenanceComponent } from './usermaintenance/usermaintenance.component';
@NgModule({
  declarations: [
    UsercardsComponent,
    UsermaintenanceComponent,
    UserlistComponent,

  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgSelectModule,
    RouterModule
  ]
})
export class UserModule { }
