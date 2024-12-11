import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatNavList } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { FooterComponent } from '../../Footer/footer/footer.component';
import { HeaderComponent } from '../../Header/header/header.component';
import { MainComponent } from '../../Main/main/main.component';
import { SidenavComponent } from '../../sidenav/sidenav.component';
import { MatDivider } from '@angular/material/divider';

@Component({
  selector: 'app-rightcolumn',
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
  templateUrl: './rightcolumn.component.html',
  styleUrls: ['./rightcolumn.component.css', '../../../Layout/Main/main/main.component.css']
})
export class RightcolumnComponent {
  communityMembers = [
    { name: 'John Doe', contribution: '12 Projects' },
    { name: 'Jane Smith', contribution: '8 Events' },
    { name: 'Chris Johnson', contribution: '15 Articles' },
  ];

  displayedColumns = ['name', 'contribution'];

  navigateTo(route: string): void {
    console.log(`Navigating to ${route}`);
  }

}
