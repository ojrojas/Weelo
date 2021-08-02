import { User } from '../models/user.model';
import {
    ADD_USER,
    DELETE_USER,
    ERROR_ACTIONS,
    GET_BY_ID_USER,
    LOAD_USERS,
    UPDATE_USER,
    UserActionTypes,
} from '../typeactions/user.typeactions';

export interface UserState {
    users: User[];
    user: User;
    id: number;
    error: any;
}

const InitialState: UserState = {
    users: [],
    user: {} as User,
    id: 0,
    error: null,
};

export const UserReducer = (
    state: UserState = InitialState,
    action: UserActionTypes,
): UserState => {
    switch (action.type) {
        case LOAD_USERS:
            return {
                ...state,
                users: action.users,
            };
        case UPDATE_USER:
            return {
                ...state,
                user: action.user,
            };
        case ADD_USER:
            return {
                ...state,
                user: action.user,
            };
        case DELETE_USER:
            return {
                ...state,
                user: action.user,
            };
        case ERROR_ACTIONS:
            return {
                ...state,
                error: action.error,
            };
            case GET_BY_ID_USER:
                return {
                    ...state,
                    user: action.user,
                };
        default:
            return state;
    }
};
