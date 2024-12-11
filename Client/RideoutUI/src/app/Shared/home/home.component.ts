import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router, RouterModule } from '@angular/router';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatSidenavModule } from '@angular/material/sidenav';


@Component({
  selector: 'app-home',
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
],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css', '../../Layout/Main/main/main.component.css']
})
export class HomeComponent {
  features = [
    { icon: 'directions_bike', title: 'Adventure Awaits', description: 'Join epic rideouts across the country.' },
    { icon: 'group', title: 'Community', description: 'Connect with like-minded riders.' },
    { icon: 'event', title: 'Host Events', description: 'Plan and manage your own rideouts.' },
  ];

  testimonials = [
    { quote: 'This platform is a game-changer for riders!', author: 'John D.' },
    { quote: 'I’ve met amazing people and gone on unforgettable rides.', author: 'Sarah T.' },
    { quote: 'Hosting a rideout has never been easier.', author: 'Chris M.' },
  ];

  constructor(private router: Router) {}

  navigateTo(route: string): void {
    this.router.navigate([`/${route}`]);
  }


  logout(): void {
    // Logic to handle logout (e.g., clearing tokens, redirecting to login)
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}