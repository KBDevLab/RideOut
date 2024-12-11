import { Component } from '@angular/core';
import { NotificationsService } from '../../../../Services/notifications.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { RouterModule, Router } from '@angular/router';
import { MatList, MatListItem } from '@angular/material/list';
import { MatDrawerContainer } from '@angular/material/sidenav';
import { MatDivider } from '@angular/material/divider';

@Component({
  selector: 'app-notificationsicon',
  imports: [
    RouterModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatList,
    MatDivider,
    MatListItem
  ],
  templateUrl: './notificationsicon.component.html',
  styleUrl: './notificationsicon.component.css'
})
export class NotificationsiconComponent {
  constructor(
    private notificationsService: NotificationsService,
    private router: Router
  ) {}

  navigateToNotifications(): void {
    this.router.navigate(['/notifications']);
  }
}
