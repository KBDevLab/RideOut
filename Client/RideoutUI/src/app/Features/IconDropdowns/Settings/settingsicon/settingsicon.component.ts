import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDivider } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-settingsicon',
  imports: [
    RouterModule,
    RouterModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatGridListModule,
    MatSidenavModule,
    MatDivider
  ],
  templateUrl: './settingsicon.component.html',
  styleUrl: './settingsicon.component.css'
})
export class SettingsiconComponent {
  constructor(
    private router: Router,
  ) {}
  
  navigateTo(route: string): void {
    this.router.navigate([`/${route}`]);
  }
  
  logout(): void {
    this.router.navigate(['/login']);
  }
}
