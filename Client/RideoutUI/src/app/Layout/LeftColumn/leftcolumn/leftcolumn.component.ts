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
  selector: 'app-leftcolumn',
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
    MatDivider,
  ],
  templateUrl: './leftcolumn.component.html',
  styleUrls: ['./leftcolumn.component.css', '../../../Layout/Main/main/main.component.css']
})
export class LeftcolumnComponent {

}
