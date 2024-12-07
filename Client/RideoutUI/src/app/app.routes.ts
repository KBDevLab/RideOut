import { Routes } from '@angular/router';
import { UsersComponent } from './Components/users/users.component';
import { HomeComponent } from './Shared/home/home.component';
import { Participants } from './Models/participants';
import { Rideout } from './Models/rideout';
import { Messages } from './Models/messages';
import { Notifications } from './Models/notifications';
import { Reviews } from './Models/reviews';
import { SigninComponent } from './Shared/signin/signin.component';
import { ReviewsComponent } from './Components/reviews/reviews.component';
import { NotitficationsComponent } from './Components/notitfications/notitfications.component';
import { MessagesComponent } from './Components/messages/messages.component';
import { RideoutComponent } from './Components/rideout/rideout.component';
import { ParticipantsComponent } from './Components/participants/participants.component';
import { TermsofserviceComponent } from './Components/termsofservice/termsofservice.component';
import { PrivacypolicyComponent } from './Components/privacypolicy/privacypolicy.component';

export const routes: Routes = 
[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'users', component: UsersComponent },
    { path: 'participants', component: ParticipantsComponent },
    { path: 'rideouts', component: RideoutComponent },
    { path: 'messages', component: MessagesComponent },
    { path: 'notifications', component: NotitficationsComponent },
    { path: 'reviews', component: ReviewsComponent },
    { path: 'signin', component: SigninComponent },
    { path: 'tos', component: TermsofserviceComponent },
    { path: 'policy', component: PrivacypolicyComponent },
    { path: '**', redirectTo: '' }
];
