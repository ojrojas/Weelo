import { uniqueId } from "lodash";
import { User } from "../models/user.model";
import { store } from "../store/store";
import { CreateUserSuccess, DeleteUserSuccess, LoadUserAction, LoadUserSuccess, UpdateUserSuccess } from "./user.actions";

describe("Test actions User", () => {
    const userValid1: User = {
      name: "test1",
      lastName: "Unit1",
      userName: "testusername",
      password: "testpassword",
      createOn: new Date(),
      createdBy: uniqueId()
    } as User;

    const userValid2: User = {
        name: "test2",
        lastName: "Unit2",
        userName: "testusername2",
        password: "testpassword2",
        createOn: new Date(),
        createdBy: uniqueId()
      } as User;

    let list: User[] = [];

    it("Create User1", () => {
      store.dispatch(CreateUserSuccess(userValid1));
      list.push(userValid1);
      let state = store.getState().users;
      expect(state.user.name).toBe("test1");
    });

    it("Create User2", () => {
      store.dispatch(CreateUserSuccess(userValid2));
      list.push(userValid2);
      
      let state = store.getState().users;
      expect(state.user.lastName).toBe("Unit2");
    });

    const newLastName = "LastNameNew";
    const userValid3 = userValid1;
    userValid3.lastName = newLastName;
   
    it("List action User", () => {
      store.dispatch(LoadUserSuccess(list));
      let state = store.getState().users;
      expect(state.users.length).toBe(2);
    });

    it("Update action User", () => {
      store.dispatch(UpdateUserSuccess(userValid3));
      let state = store.getState().users;
      expect(state.user.lastName).toBe(newLastName);
    });

    it("Delete action User", () => {
      store.dispatch(DeleteUserSuccess(userValid3));
      let state = store.getState().users;
      expect(state.user).toBe(userValid3);
    });
  });
