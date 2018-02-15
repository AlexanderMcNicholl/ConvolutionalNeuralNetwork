using System;

namespace CShardNeuralNetwork {

    class Network
    {
        static double[][][] synapses;
        static double[][] layers;

        static void constructNetwork(double[] inputs, int[] hiddenLayerLength, double[] expected) //Method to construct the network.
        {
            //Initializing layers.
            int layerSize = inputs.Length + hiddenLayerLength.Length + expected.Length;
            layers = new double[layerSize][];
            layers[0] = inputs;
            for (int i = 0; i < hiddenLayerLength.Length; i++)
            {
                double[] hidden_layer = initializeArray(hiddenLayerLength[i], 0, 1);
                layers[1 + i] = hidden_layer;
            }
            layers[layers.Length - 1] = expected;

            printNetwork(inputs, hiddenLayerLength, expected);
        }
        static void Main()
        {
            constructNetwork(new double[] { 1, 7, 4 }, new int[] { 8, 8, 8, 4, 9, 2, 7 }, new double[] { 6, 1, 1 });
            Console.ReadLine();
        }

        static double[] initializeArray(int arrayLength, int minVal, int maxVal)
        {
            Random r = new Random();
            double[] returnArray = new double[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                returnArray[i] = r.NextDouble() * (maxVal - minVal) + minVal;
            }
            return returnArray;
        }

        static void assignWeights()
        {
            for (int i = 0; i < layers[0].Length; i++)
            {

            }
        }

        static void printNetwork(double[] inputs, int[] hiddenLayerLength, double[] expected) //Method to print the networks layers and all of its neurons.
        {
            int layerSize = inputs.Length + hiddenLayerLength.Length + expected.Length;
            Console.WriteLine();
            Console.WriteLine("Input layer:");
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < layers[0].Length; i++)
            {
                Console.WriteLine("Input layer (Neuron " + (i + 1) + "): " + layers[0][i]);
            }
            Console.WriteLine();
            Console.WriteLine("Hidden Layers:");
            Console.WriteLine("------------------------------------------------------------");
            for (int hiddenLayer = 1; hiddenLayer < hiddenLayerLength.Length + 1; hiddenLayer++)
            {
                for (int i = 0; i < layers[hiddenLayer].Length; i++)
                {
                    Console.WriteLine("Hidden layer: " + hiddenLayer + " (Neuron " + (i + 1) + "): " + layers[hiddenLayer][i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Expected output layers:");
            Console.WriteLine("------------------------------------------------------------");
            for (int i = 0; i < layers[layerSize - 1].Length; i++)
            {
                Console.WriteLine("Expect output layer (Neuron " + (i + 1) + "): " + layers[layerSize - 1][i]);
            }
        }
    }
}

















//Why did you scroll past the last bracket you nunce