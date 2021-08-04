import { combineReducers } from 'redux';
import { LoginReducer } from '../reducer/login.reducer';
import { OwnerReducer } from '../reducer/owner.reducer';
import { PropertyImageReducer } from '../reducer/property-image.reducer';
import { PropertyTraceReducer } from '../reducer/property-trace.reducer';
import { PropertyReducer } from '../reducer/property.reducer';
import { UserReducer } from '../reducer/user.reducer';

export const rootReducer = combineReducers({
    users: UserReducer,
    login: LoginReducer,
    property:PropertyReducer,
    propertyImage:PropertyImageReducer,
    propertyTrace:PropertyTraceReducer,
    owners: OwnerReducer
  
});

export type AppState = ReturnType<typeof rootReducer>;