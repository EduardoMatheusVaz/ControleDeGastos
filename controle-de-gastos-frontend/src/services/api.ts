const API_BASE_URL = "https://localhost:7203/api";

export const api = {
  get: async <T>(endpoint: string): Promise<T> => {
    const url = `${API_BASE_URL}/${endpoint}`.replace(/([^:]\/)\/+/g, "$1");

    const response = await fetch(url);

    if (!response.ok) {
      const error = await response.text();
      console.error("Erro backend:", error);
      throw new Error("Erro na requisição");
    }

    return response.json();
  },

  post: async <T, U = undefined>(
    endpoint: string,
    data?: U
  ): Promise<T> => {
    const url = `${API_BASE_URL}/${endpoint}`.replace(/([^:]\/)\/+/g, "$1");

    const response = await fetch(url, {
      method: "POST",
      headers: data ? { "Content-Type": "application/json" } : undefined,
      body: data ? JSON.stringify(data) : undefined,
    });

    if (!response.ok) {
      const error = await response.text();
      console.error("Erro backend:", error);
      throw new Error("Erro ao enviar dados");
    }

    return response.json();
  },

  put: async <T, U = undefined>(
    endpoint: string,
    data?: U
  ): Promise<T> => {
    const url = `${API_BASE_URL}/${endpoint}`.replace(/([^:]\/)\/+/g, "$1");

    const response = await fetch(url, {
      method: "PUT",
      headers: data ? { "Content-Type": "application/json" } : undefined,
      body: data ? JSON.stringify(data) : undefined,
    });

    if (!response.ok) {
      const error = await response.text();
      console.error("Erro backend:", error);
      throw new Error("Erro ao atualizar dados");
    }

    return response.json();
  },

  delete: async (endpoint: string): Promise<void> => {
    const url = `${API_BASE_URL}/${endpoint}`.replace(/([^:]\/)\/+/g, "$1");

    const response = await fetch(url, {
      method: "DELETE",
    });

    if (!response.ok) {
      const error = await response.text();
      console.error("Erro backend:", error);
      throw new Error("Erro ao deletar");
    }
  },
};