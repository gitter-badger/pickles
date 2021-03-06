﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="JsonScenarioTests.cs" company="PicklesDoc">
//  Copyright 2011 Jeffrey Cameron
//  Copyright 2012-present PicklesDoc team and community contributors
//
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using NFluent;
using NUnit.Framework;
using PicklesDoc.Pickles.ObjectModel;

namespace PicklesDoc.Pickles.Test.ObjectModel.Json
{
    using PicklesDoc.Pickles.DocumentationBuilders.JSON;

    [TestFixture]
    public class JsonScenarioTests
    {
        private readonly Factory factory = new Factory();

        [Test]
        public void MapToScenario_Always_MapsFeatureProperty()
        {
            var feature = new Feature
                              {
                                  Name = "My Feature",
                                  Description = "My Description",
                                  FeatureElements = { new Scenario { Name = "My Feature" } }
                              };

            var mapper = new JsonMapper();

            var mappedFeature = mapper.Map(feature);

            Check.That(mappedFeature.FeatureElements.Count).IsEqualTo(1);

            var mappedScenario = mappedFeature.FeatureElements[0] as JsonScenario;

            Check.That(mappedScenario.Feature).IsSameReferenceThan(mappedFeature);
        }

    }
}