import { Routes } from '@angular/router';
import { UsersComponent } from './Components/users/users.component';
import { HomeComponent } from './Shared/home/home.component';
import { ReviewsComponent } from './Components/reviews/reviews.component';
import { MessagesComponent } from './Components/messages/messages.component';
import { RideoutComponent } from './Components/rideout/rideout.component';
import { ParticipantsComponent } from './Components/participants/participants.component';
import { TermsofserviceComponent } from './Components/termsofservice/termsofservice.component';
import { PrivacypolicyComponent } from './Components/privacypolicy/privacypolicy.component';
import { LoginComponent } from './Shared/login/login.component';
import { RegisterComponent } from './Shared/register/register.component';
import { ProfileComponent } from './Components/users/profile/profile.component';
import { MainComponent } from './Layout/Main/main/main.component';
import { AboutComponent } from './Components/about/about.component';
import { SettingsComponent } from './Features/Settings/settings/settings.component';
import { NotificationsComponent } from './Components/notifications/notifications.component';

export const routes: Routes = 
[
    { path: '', component: MainComponent,
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'users', component: UsersComponent },
            { path: 'participants', component: ParticipantsComponent },
            { path: 'rideouts', component: RideoutComponent },
            { path: 'messages', component: MessagesComponent },
            { path: 'notifications', component: NotificationsComponent },
            { path: 'reviews', component: ReviewsComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: 'tos', component: TermsofserviceComponent },
            { path: 'policy', component: PrivacypolicyComponent },
            { path: 'users/profile', component: ProfileComponent },
            { path: 'about', component: AboutComponent },
            { path: 'settings', component: SettingsComponent },
            { path: '**', redirectTo: '' }
        ]
    },
];
