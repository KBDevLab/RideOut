import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../../Services/user.service';
import { User } from '../../Models/user';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button'; 
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  imports: [
    CommonModule, 
    MatCardModule, 
    MatButtonModule 
  ],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {
  user: User | null = null;
  private subscriptions: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.subscriptions.add(
      this.route.paramMap.subscribe(params => {
        const userId = params.get('id');
        if (userId) {
          this.fetchUser(userId);
        }
      })
    );
  }

  private fetchUser(userId: string): void {
    this.subscriptions.add(
      this.userService.getUserById(userId).subscribe(
        user => {
          this.user = user;
        },
        error => {
          console.error('Error fetching user:', error);
        }
      )
    );
  }

  editUser(): void {
    if (!this.user) return;
    this.router.navigate(['/users/edit', this.user.Userid]);
  }

  deleteUser(): void {
    if (!this.user) return;
    if (confirm(`Are you sure you want to delete ${this.user.Name}?`)) {
      this.subscriptions.add(
        this.userService.deleteUser(this.user.Userid).subscribe(
          () => {
            console.log('User deleted successfully');
            this.router.navigate(['/users']);
          },
          error => {
            console.error('Error deleting user:', error);
          }
        )
      );
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}