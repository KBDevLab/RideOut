import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { UsersComponent } from '../users.component';
import {MatTabsModule} from '@angular/material/tabs';
import { User } from '../../../Models/user';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RideoutComponent } from '../../rideout/rideout.component';
import {MatTableModule} from '@angular/material/table';
import { Rideout } from '../../../Models/rideout';


@Component({
  selector: 'app-profile',
  imports: [
    RouterModule,
    MatTableModule,
    MatTabsModule,
    RouterModule,
    RouterModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatGridListModule,
    MatSidenavModule
  ],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css', '../../../Layout/Main/main/main.component.css']
})
export class ProfileComponent {
  user: User | null = null;
  rideouts: Rideout | null = null;
}
