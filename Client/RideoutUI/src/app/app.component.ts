import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MainComponent } from "./Layout/Main/main/main.component";
import { SidenavComponent } from './Layout/sidenav/sidenav.component';
import { FooterComponent } from './Layout/Footer/footer/footer.component';
import { HeaderComponent } from './Layout/Header/header/header.component';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    MatSidenavModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'RideoutUI';
}
