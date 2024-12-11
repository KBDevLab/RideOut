import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule, MatIconButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterModule } from '@angular/router';
import { ProfileiconComponent } from "../../../Features/IconDropdowns/Profile/profileicon/profileicon.component";
import { SettingsiconComponent } from "../../../Features/IconDropdowns/Settings/settingsicon/settingsicon.component";
import { NotificationsiconComponent } from '../../../Features/IconDropdowns/Notifications/notificationsicon/notificationsicon.component';

@Component({
  selector: 'app-header',
  imports: [
    RouterModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    SettingsiconComponent,
    NotificationsiconComponent,
    ProfileiconComponent,
    SettingsiconComponent
],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isAuthenticated: boolean = false;

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

}