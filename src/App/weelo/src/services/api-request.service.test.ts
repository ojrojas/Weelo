import { uniqueId } from "lodash";
import { Owner } from "../models/owner.model";
import { ApiRequest } from "./api-request.service";

const getUrl = "list-owners";
const postUrl = "create-owner";
const deletesUrl = "delete-owner/";
const updateUrl = "update-owner";
const getbyidUrl = "getbyid-owner/";

jest.mock("axios", () => {
  return {
    create: jest.fn(() => ({
      interceptors: {
        request: { use: jest.fn(), eject: jest.fn() },
        response: { use: jest.fn(), eject: jest.fn() },
      },
      Get: jest.fn(() => "default"),
      Post: jest.fn(() => "default"),
      Delete: jest.fn(() => "default"),
      Update: jest.fn(() => "default"),
    })),
  };
});

const listOwners: Owner[] = [
  {
    name: "prueba de owner 1",
    address: "ever green",
    birthday: new Date(),
    createOn: new Date(),
    id: uniqueId(),
    photo: "photo1",
    state: true,
    createdBy: uniqueId(),
  } as Owner,
  {
    name: "prueba de owner 2",
    address: "ever red",
    birthday: new Date(),
    createOn: new Date(),
    id: uniqueId(),
    photo: "photo1",
    state: true,
    createdBy: uniqueId(),
  } as Owner,
];

const apiService = new ApiRequest();

describe("Test Api Request Service", () => {
  //Get owners
  test("list owners request weelo api", async () => {
    const data = {
      listOwners,
    };
    const get = apiService.Get as jest.Mock;
    await expect(apiService.Get(getUrl)).resolves.toEqual({
      data,
    });
  });

  //Create owner
  test("create owner weelo api", async () => {
    const data = {
      name: "prueba de owner 3",
      address: "ever red",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photo3",
      state: true,
      createdBy: uniqueId(),
    };

    const post = apiService.Post as jest.Mock;
    post.mockImplementationOnce(() =>
      Promise.resolve({
        data,
      })
    );
    await expect(apiService.Post(postUrl, data)).resolves.toEqual({
      data,
    });
  });

  //Update owner
  test("update owner weelo api", async () => {
    const data = {
      name: "prueba de owner update",
      address: "ever red update",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photo3",
      state: true,
      createdBy: uniqueId(),
    };
    const post = apiService.Put as jest.Mock;
    post.mockImplementationOnce(() =>
      Promise.resolve({
        data,
      })
    );
    await expect(apiService.Put(updateUrl, data)).resolves.toEqual({
      data,
    });
  });

  //delete owner
  test("delete owner weelo api", async () => {
    const data = {
      name: "delete de owner update",
      address: "ever red delete",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photoe",
      state: true,
      createdBy: uniqueId(),
    };

    const post = apiService.Delete as jest.Mock;
    post.mockImplementationOnce(() =>
      Promise.resolve({
        data,
      })
    );
    await expect(apiService.Delete(deletesUrl)).resolves.toEqual({
      data,
    });
  });

  // Get by id owner
  test("get by id owner weelo api", async () => {
    const data = {
      name: "get by id de owner update",
      address: "ever red by id",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photoe",
      state: true,
      createdBy: uniqueId(),
    };
    const del = apiService.Get as jest.Mock;
    del.mockImplementationOnce(() =>
      Promise.resolve({
        data,
      })
    );
    await expect(apiService.Get(getbyidUrl)).resolves.toEqual({
      data,
    });
  });
});
