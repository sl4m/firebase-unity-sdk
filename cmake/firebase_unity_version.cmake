# Copyright 2019 Google
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

# This file defines the version numbers used by the Firebase Unity SDK.

set(FIREBASE_UNITY_SDK_VERSION "7.1.0"
    CACHE STRING "The version of the Unity SDK, used in the names of files.")

set(FIREBASE_IOS_POD_VERSION "7.8.0"
    CACHE STRING "The version of the top-level Firebase Cocoapod to use.")

set(FIREBASE_INSTANCE_ID_POD_VERSION "4.3.1"
    CACHE STRING "The version of the FirebaseInstanceId Cocoapod to use.")

# https://github.com/googlesamples/unity-jar-resolver
set(FIREBASE_UNITY_JAR_RESOLVER_VERSION
  "1.2.165"
   CACHE STRING
  "Version tag of Play Services Resolver to download and use (no trailing .0)"
)
