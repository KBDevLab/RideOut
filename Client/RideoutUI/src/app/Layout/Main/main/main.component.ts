import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbar } from '@angular/material/toolbar';
import { RightcolumnComponent } from "../../RightColumn/rightcolumn/rightcolumn.component";
import { LeftcolumnComponent } from "../../LeftColumn/leftcolumn/leftcolumn.component";
import { HeaderComponent } from "../../Header/header/header.component";
import { FooterComponent } from "../../Footer/footer/footer.component";

@Component({
  selector: 'app-main',
  imports: [
    RouterModule,
    RouterModule,
    RouterModule,
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatGridListModule,
    MatSidenavModule,
    RightcolumnComponent,
    LeftcolumnComponent,
    HeaderComponent,
    FooterComponent
],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent implements OnInit{
  @ViewChild('sidenav') sidenav: MatSidenav | undefined;
  currentRoute: string | null = null;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.url.subscribe(url => {
      this.currentRoute = url[0].path;
      this.updateSidebars(); // Method to update sidebars based on current route
    });
  }

  toggleSidenav() {
    if (this.sidenav) {
      this.sidenav.toggle();
    } else {
      console.warn('Sidenav not yet available.');
    }
  }

  updateSidebars() {
    switch(this.currentRoute) {
      case 'users':

        break;
      case 'profile':

        break;

    }
  }
}
