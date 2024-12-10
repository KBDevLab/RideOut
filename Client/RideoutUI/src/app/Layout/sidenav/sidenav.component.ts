import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router, RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatNavList} from '@angular/material/list';
import {MatListModule} from '@angular/material/list';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MatToolbar } from '@angular/material/toolbar';

@Component({
  selector: 'app-sidenav',
  imports: [
    RouterModule,
    CommonModule, 
    MatCardModule, 
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatSidenavModule,
    MatNavList,
    MatListModule,
    MatToolbar
  ],
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  currentRoute: string = '';
  navItems = [
    { label: 'Home', icon: 'home', route: '/home' },
    { label: 'Explore RideOuts', icon: 'explore', route: '/ride-outs' },
    { label: 'Host a RideOut', icon: 'event', route: '/host-ride-out' },
    { label: 'Notifications', icon: 'notifications', route: '/notifications' },
    { label: 'Profile', icon: 'person', route: '/profile' },
  ];

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.currentRoute = this.router.url;
  }

  toggleSidenav(sidenav: any): void {
    sidenav.toggle();
  }

  onNavigate(route: string): void {
    this.router.navigate([route]);
    this.currentRoute = route;
  }
}