import { Component } from '@angular/core';
import { HeaderComponent } from "../../Header/header/header.component";
import { FooterComponent } from "../../Footer/footer/footer.component";
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-main',
  imports: [HeaderComponent, FooterComponent, RouterModule],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {

}
