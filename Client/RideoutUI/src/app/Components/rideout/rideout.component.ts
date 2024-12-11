import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatList, MatListItem } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatOption, MatSelect } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTab, MatTabGroup } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-rideout',
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
    MatList,
    MatListItem,
    MatTabGroup,
    MatTab,

  ],
  templateUrl: './rideout.component.html',
  styleUrl: './rideout.component.css'
})
export class RideoutComponent {
  searchQuery = '';
  selectedFilter = '';
  filters = ['All', 'Upcoming', 'Past', 'Popular'];

  rideouts = [
    {
      name: 'City Night Cruise',
      location: 'Downtown LA',
      date: new Date(),
      participants: 25,
      maxParticipants: 30,
      isFull: false,
    },
    {
      name: 'Beachside Ride',
      location: 'Santa Monica',
      date: new Date(new Date().setDate(new Date().getDate() + 5)),
      participants: 30,
      maxParticipants: 30,
      isFull: true,
    },
    {
      name: 'Mountain Adventure',
      location: 'Big Bear',
      date: new Date(new Date().setDate(new Date().getDate() + 10)),
      participants: 10,
      maxParticipants: 20,
      isFull: false,
    },
  ];

  get filteredRideouts() {
    return this.rideouts.filter(
      (event) =>
        (this.selectedFilter === 'All' || !this.selectedFilter || event.isFull === false) &&
        (event.name.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
          event.location.toLowerCase().includes(this.searchQuery.toLowerCase()))
    );
  }

  clearSearch() {
    this.searchQuery = '';
  }

  createRideout() {
    console.log('Navigate to create rideout page');
  }

  viewDetails(event: any) {
    console.log('View details for:', event.name);
  }

  joinRideout(event: any) {
    console.log('Join rideout:', event.name);
  }

}
